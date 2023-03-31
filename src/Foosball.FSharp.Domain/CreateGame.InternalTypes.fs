module internal Foosball.Domain.CreateGame.InternalTypes

open Foosball.Domain.Common
open System

type UnvalidatedPlayer = { PlayerId: Guid; PlayerName: string }

type UnvalidatedOnePlayerTeam =
    { TeamId: Guid
      TeamName: string
      PlayerId: Guid }

type UnvalidatedTwoPlayerTeam =
    { TeamId: Guid
      TeamName: string
      FirstPlayerId: Guid
      SecondPlayerId: Guid }

type UnvalidatedOneOrTwoPlayerTeam =
    | OnePlayerTeam of UnvalidatedOnePlayerTeam
    | TwoPlayerTeam of UnvalidatedTwoPlayerTeam

type UnvalidatedOneOrTwoPlayerTeams =
    { FirstTeam: UnvalidatedOneOrTwoPlayerTeam
      SecondTeam: UnvalidatedOneOrTwoPlayerTeam }

type OneOrTwoPlayerTeam =
    | OnePlayerTeam of OnePlayerTeam
    | TwoPlayerTeam of TwoPlayerTeam

type OnePlayerTeams =
    { FirstTeam: OnePlayerTeam
      SecondTeam: OnePlayerTeam }

type TwoPlayerTeams =
    { FirstTeam: TwoPlayerTeam
      SecondTeam: TwoPlayerTeam }

type SameCompositionTeams =
    | OnePlayerTeams of OnePlayerTeams
    | TwoPlayerTeams of TwoPlayerTeams

type ValidatedTeams = ValidatedTeams of SameCompositionTeams

type TeamNotFoundError = TeamNotFoundError
type TeamValidationError = TeamValidationError
type PlayerNotFoundError = PlayerNotFoundError
type PlayerValidationError = PlayerValidationError

type GetTeam = Guid -> Async<Result<UnvalidatedOneOrTwoPlayerTeam, TeamNotFoundError>>
type GetPlayer = Guid -> Async<Result<UnvalidatedPlayer, PlayerNotFoundError>>

type ValidateTeam = UnvalidatedOneOrTwoPlayerTeam -> Result<OneOrTwoPlayerTeam, TeamValidationError>
type ValidatePlayer = UnvalidatedPlayer -> Result<Player, PlayerValidationError>
type ValidateTeams = UnvalidatedOneOrTwoPlayerTeams -> Result<ValidatedTeams, TeamValidationError>
