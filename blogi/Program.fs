open Giraffe
open Microsoft.AspNetCore.Builder
open Blogi.Infrastructure.Web

let webApp =
    choose [
        GET >=> routef "/posts/%s" getPostHandler
        POST >=> route "/posts" >=> createPostHandler
        GET >=> route "/" >=> text "Welcome to Blogi!"
    ]

[<EntryPoint>]
let main args =
    let builder = WebApplication.CreateBuilder(args)
    builder.Services.AddGiraffe() |> ignore
    let app = builder.Build()
    app.UseGiraffe webApp
    app.Run()
    0