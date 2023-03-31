namespace Foosball.Domain.CreateGame

open Foosball.Domain.Common
open System

// Input of the workflow
type UnvalidatedTeamIds =
    { FirstTeamId: Guid
      SecondTeamId: Guid }


// Events of the workflow
type GameCreated =
    { GameId: GameId
      FirstTeamId: TeamId
      SecondTeamId: TeamId
      StartedAt: DateTime }

type GameCreatedEvent = GameCreatedEvent of GameCreated


// Errors of the workflow
type ValidationError = TeamsValidationError of string
type NotFoundError = MissingTeamsError of string

type CreateGameError =
    | ValidationError of ValidationError
    | NotFoundError of NotFoundError


// Type of the workflow
type CreateGame = UnvalidatedTeamIds -> Async<Result<GameCreatedEvent, CreateGameError>>
