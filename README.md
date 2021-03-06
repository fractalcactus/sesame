# Sesame 

Grand prize winner of the [2014 Cap App Challenge](https://viccareers.com/2014/11/29/the-cap-app-challenge/):

> "A team of current and former Victoria University students, meanwhile, took top prize in the Cap App Challenge. Victoria graduate George Feast-Parker, former student Katherine Anderson and current part time law student Gabrielle Young took out the top prize with their app, Sesame, which they describe as a real world treasure map for users to leave checkpoints on a live map and link to content. The three met and came up with the idea for Sesame while taking part in a nine-week intensive software development course. They have since all found jobs in the technology sector. The team won $10,000"
https://techblog.nz/891-Hot-News-in-IT-this-week

- unlock messages/videos/music when you reach a checkpoint, set by some one else on a map.
- uses html5 gps and the google maps API


## previously hosted at
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



