namespace Foosball.Domain.Common


type FullName =
    { FirstName: NonEmptyString
      LastName: NonEmptyString }


type Player =
    { PlayerId: PlayerId
      PlayerName: NonEmptyString }


type OnePlayerTeam =
    { TeamId: TeamId
      TeamName: NonEmptyString
      Player: Player }

type TwoPlayerTeam =
    { TeamId: TeamId
      TeamName: NonEmptyString
      FirstPlayer: Player
      SecondPlayer: Player }

type Scores =
    { TeamAScore: Goals; TeamBScore: Goals }

type Set =
    { GameId: GameId
      TeamAId: TeamId
      TeamBId: TeamId
      Scores: Scores }
