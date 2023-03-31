namespace Foosball.Domain.Common

open System

type NonEmptyString = private NonEmptyString of string
type Goals = private Goals of int
type GameId = private GameId of Guid
type SetId = private SetId of Guid
type PlayerId = private PlayerId of Guid
type TeamId = private TeamId of Guid

module NonEmptyString =
    let value (NonEmptyString str) = str

    let create fieldName str =
        if String.IsNullOrWhiteSpace(str) then
            let msg = sprintf "%s cannot be null, empty or whitespace." fieldName
            Error msg
        else
            Ok str

module MaxGoals =
    let value = 10

module Goals =
    let value (Goals goals) = goals

    let create value =
        if value < 0 then
            let msg = sprintf "Goals cannot have a negative value"
            Error msg
        elif value > MaxGoals.value then
            let msg = sprintf "Goals cannot have a value higher than %i" MaxGoals.value
            Error msg
        else
            Ok value

module GameId =
    let value (GameId id) = id
    let create () = Guid.NewGuid() |> GameId
    let fromExisting id = id |> GameId

module SetId =
    let value (SetId id) = id
    let create () = Guid.NewGuid() |> SetId
    let fromExisting id = id |> SetId

module PlayerId =
    let value (PlayerId id) = id
    let create () = Guid.NewGuid() |> PlayerId
    let fromExisting id = id |> PlayerId

module TeamId =
    let value (TeamId id) = id
    let create () = Guid.NewGuid() |> TeamId
    let fromExisting id = id |> TeamId
