namespace Foosball.FSharp.API

open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.Hosting
open Giraffe
open Router

module Program =

    let exitCode = 0

    [<EntryPoint>]
    let main args =

        let builder = WebApplication.CreateBuilder(args)
        let services = builder.Services

        services.AddGiraffe() |> ignore

        let app = builder.Build()

        app.UseGiraffe router

        app.Run()

        exitCode
