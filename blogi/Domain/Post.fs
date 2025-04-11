module Blogi.Domain.Post

open System

type Post = {
    Id: Guid
    Title: string
    Slug: string  // e.g., "my-first-post"
    Content: string  // Markdown content
    CreatedAt: DateTime
}

let validate post =
    if String.IsNullOrEmpty post.Title then Error "Title is required"
    elif String.IsNullOrEmpty post.Slug then Error "Slug is required"
    else Ok post