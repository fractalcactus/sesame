# Clearing House

# hosted at
 `http://worldplayground.azurewebsites.net/`

## Dev Goals

- GFP: 1. JS 2.Rails
- GY: C# backend stuff, mapbox JS integration
- A: MVC JS
- K: Rails and JS
- after MVP, learning has priority over product completion

## Sesame API Documentation

This API is written in C# and consumed by the front end JS

### Glossary:

- **Waypoint:** an entry in the WayPoint DB which has a lat, lng, url and id
- **Path:** a collection of WayPoints


### Public Routes

#### POST api/WayPoints

*Description:*
This works like a GET, but needs to be a post so it can take a JSON. Takes a lat and lng in the form of a json string, checks if those coords are in the DB, evenutally having a range of acceptable points (e.g a radius of being at a WayPoint)

*expects:*
```json
'{"Lat": "3", "Long":"4"}'
```
*Success:*
```json
{
    "Id": 3,
    "Lat": 3,
    "Lng": 0,
    "URL": "https://www.youtube.com/watch?v=JIOCc0tfoqA"
}
```
*Error:*
`Status Code - 400`

