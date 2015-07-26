namespace Chatter.Server

open FSharpx.Collections

module ChatPage =
    let renderShell inner = seq {
        yield 
            """<html>
                 <head><title>Chatter</title></head>
                 <body>"""

        yield! inner

        yield  
            """  </body>
               </html>""" }

    let renderRoom (room : Room) = seq {
        yield sprintf """<a href="/room/%s">%s</a>""" room room
    }

    let renderRoomList (rooms : list<Room>) = seq {
        yield "<ul>"

        for room in rooms do
            yield "<li>"
            yield! renderRoom room
            yield "</li>"

        yield "</ul>"
    }
        
    let render (pageState : PageState) = 
       renderShell (renderRoomList pageState.Rooms)