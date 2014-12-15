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

#### GET api/WayPoints

*Description:*
 Takes a lat and lng IN PARAMS, checks if those coords are in the DB, evenutally having a range of acceptable points (e.g a radius of being at a WayPoint)

*expects:*
```json
"api/WayPoints?lat="+userLat+"&lng="+userLng
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

#### GET api/?id=x

*Description:*
 Takes a single marker ID and returns that marker as a JSON object.

*expects:*
```id parameter
"api/WayPoints?id="markerID
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

#### GET api/WayPoints

*Description:*
No parameters, returns all Waypoints in database as an array of JSON objects

*expects:*
nothing

*Success:*
```json
[
    {
        "Id": 1,
        "Lat": 174.780136,
        "Lng": -41.1232147,
        "URL": "https://www.youtube.com/watch?v=PS_b6TthSGQ"
    },
    {
        "Id": 3,
        "Lat": 3,
        "Lng": 4,
        "URL": "https://www.youtube.com/watch?v=JIOCc0tfoqA"
    },
    {
        "Id": 4,
        "Lat": 174.780136,
        "Lng": -41.1232147,
        "URL": "Iaddedthis"
    },
    {
        "Id": 5,
        "Lat": 174.780136,
        "Lng": -41.1232147,
        "URL": "Ialsoaddedthis"
    }
]
```
*Error:*
`Status Code - 400`


#### POST api/WayPoints

*Description:*
adds a waypoint into the DB and returns everything with an id 

*expects:*
```json
'{"Lat": 174.780136, "Lng": -41.1232147, "URL": "Ialsoaddedthis"}'
```
*Success:*
```json
{
    "Id": 6,
    "Lat": 174.780136,
    "Lng": -41.1232147,
    "URL": "Ialsoaddedthis"
}
```
*Error:*
`Status Code - 400`

