module Blogi.Infrastructure.Storage

open System.IO
open Blogi.Domain.Post

let private postsPath = "posts"

let savePost post =
    let json = System.Text.Json.JsonSerializer.Serialize(post)
    Directory.CreateDirectory(postsPath) |> ignore
    File.WriteAllText(Path.Combine(postsPath, $"{post.Slug}.json"), json)

let loadPost slug =
    let path = Path.Combine(postsPath, $"{slug}.json")
    if File.Exists path then
        File.ReadAllText path |> System.Text.Json.JsonSerializer.Deserialize<Post> |> Some
    else None