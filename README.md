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

#### GET /trades/since/:trade_id

*Description:*
Returns array of trade hashes, including and after trade id

*Success:*
```json
[
	{ "id"=>987, "bid_id"=>12345, "ask_id"=>3424, "price"=>25.80, "volume"=>23, "time_placed"=>[timestamp] },
	{ "id"=>986, "bid_id"=>14563, "ask_id"=>1224, "price"=>23.20, "volume"=>23, "time_placed"=>[timestamp] },
	etc..
]
```

*Error:*
`Status Code - 400`

#### GET /accounts

*Description:*
Success data returns all accounts and info, sorted from most josh coins to least josh coins

*Success:*
```json
[
	{ "id"=>384, "user_id"=>123, "josh_coins"=>258, "dollars"=>234 },
	{ "id"=>382, "user_id"=>6312, "josh_coins"=>257.1, "dollars"=>200 }
]
```

*Error:*
`Status Code - 400`

#### POST /accounts/create/0-1-0

*Description:*
Creates a new account for a user. Generates api key, and sets balance to 100$ and 100JC. On success, returns api key, and on failure, returns status code 400. (This endpoint is versioned).
Supported Versions:
- 0-1-0 (current)

*Data:*
```json
{ "user_id"=>1237, "email"=>"gmail@gmail.gmail" }
```

*Success:*
```json
{ "api_key"=>[API_KEY] } 
```

*Error:*
`Status Code - 400`

###Private Routes

#### POST /account/orders/bids/create

*Description:*
Creates a new bid

*Data:*
```json
{ "api_key"=>API_KEY, "volume"=>234, "price"=>12 }
```

*Success:*
```json
{ "id"=>3232, "volume"=>234, "price"=>12 }
```

*Error:*
`Status Code - 400`

#### POST /account/orders/asks/create

*Description:*
Creates a new ask

*Data:*
```json
{ "api_key"=>API_KEY, "volume"=>54, "price"=>8 }
```

*Success:*
```json
{ "id"=>4532, "volume"=>54, "price"=>8 }
```

*Error:*
`Status Code - 400`

#### PUT /account/orders/bids/:bid_id/cancel

*Description:*
Cancels a bid

*Data:*
```json
{ "api_key"=>[API_KEY] }
```

*Success:*
`Status Code - 200`

*Error:*
`Status Code - 400`

#### PUT /account/orders/asks/:ask_id/cancel

*Description:*
Cancels an ask

*Data:*
```json
{ "api_key"=>[API_KEY] }
```

*Success:*
`Status code - 200`

*Error:*
`Status code - 400`

#### GET /account/balance?api_key=[API_KEY]

*Description:*
Returns account balance

*Success:*
```json
{ "id"=>3612, "josh_coins"=>12, "dollars"=>82 }
```

*Error:*
`Status Code - 400`

#### GET /account/orders/bids?api_key=[API_KEY]

*Description:*
Returns all of a users' bids

*Success:*
```json
[
	{ "id"=>1234, "price"=>23.20, "volume"=>1, "time_placed"=>[timestamp]},
	{ "id"=>2342, "price"=>23, "volume"=>21, "time_placed"=>[timestamp]}
]
```

*Error:*
`Status Code - 400`

#### GET /account/orders/asks?api_key=[API_KEY]

*Description:*
Returns all of a users' asks

*Success:*
```json
[
	{ "id"=>1234, "price"=>23.20, "volume"=>1, "time_placed"=>[timestamp] },
	{ "id"=>2342, "price"=>23, "volume"=>21, "time_placed"=>[timestamp] }
]
```

*Error:*
`Status Code - 400`
