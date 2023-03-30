module Router

open Giraffe
open Microsoft.AspNetCore.Http

let router: HttpFunc -> HttpContext -> HttpFuncResult =
    choose [ route "/ping" >=> text "pong"; route "/" >=> htmlFile "/pages/index.html" ]
