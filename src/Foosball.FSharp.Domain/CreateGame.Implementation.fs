module internal Foosball.Domain.CreateGame.Implementation

open FsToolkit.ErrorHandling
open Foosball.Domain.CreateGame.InternalTypes
open Foosball.Domain.Common

let toTwoPlayerTeam : GetPlayer -> UnvalidatedTwoPlayerTeam -> Result<TwoPlayerTeam, TeamValidationError> =
    fun getPlayer unvalidatedTeam ->
        asyncResult {
            let! firstPlayer =
                getPlayer unvalidatedTeam.FirstPlayerId

            let! secondPlayer =
                getPlayer unvalidatedTeam.SecondPlayerId

            let teamId =
                unvalidatedTeam.TeamId
                |> TeamId.fromExisting

            let teamName =
                unvalidatedTeam.TeamName
                |> NonEmptyString.create "TeamName"
                |> Result.mapError TeamValidationError

            return { TeamId = teamId; TeamName = teamName; FirstPlayer = firstPlayer; SecondPlayer = secondPlayer }
        }
        


let createGame
    (getTeam : GetTeam) // Dependency
    getPlayer // Dependency
    : CreateGame =
    fun unvalidatedTeamIds -> asyncResult { 
        let! firstUnvalidatedOneOrTwoPlayerTeam = 
            getTeam unvalidatedTeamIds.FirstTeamId
            |> AsyncResult.mapError NotFoundError
        
        let! secondUnvalidatedOneOrTwoPlayerTeam = 
            getTeam unvalidatedTeamIds.SecondTeamId

     }
