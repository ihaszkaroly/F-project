module Blogi.Infrastructure.Web

open Giraffe
open Microsoft.AspNetCore.Http
open Blogi.Domain.Post

let getPostHandler slug : HttpHandler =
    fun next ctx ->
        match Storage.loadPost slug with
        | Some post -> ctx.WriteHtmlStringAsync (Markdown.toHtml post.Content)
        | None -> 
            ctx.SetStatusCode 404
            ctx.WriteTextAsync "Post not found"

let createPostHandler : HttpHandler =
    fun next ctx ->
        task {
            let! post = ctx.BindJsonAsync<Post>()
            match validate post with
            | Ok validPost -> 
                Storage.savePost validPost
                return! json validPost next ctx
            | Error e -> 
                ctx.SetStatusCode 400
                return! json e next ctx
        }