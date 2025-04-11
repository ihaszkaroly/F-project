module Blogi.Domain.Markdown

open Markdig

let toHtml (markdown: string) =
    Markdig.Markdown.ToHtml(markdown)