    var markers = [
    {id:1,lat:-41.292936, lng:174.778219},
    {id:2,lat:-41.282786, lng:174.766310},
    {id:3,lat:-41.303866, lng:174.742127},
    {id:4,lat:-41.311305, lng:174.818388},
    {id:5,lat:-41.278163, lng:174.777446}
    ]

  var PointMarker = function(item) {
    this.lat = item.lat;
    this.lng = item.lng;
    this.point_id = item.id;
  }

  PointMarker.prototype = {
    placeMarker: function(map) {
      console.log("Inside placing marker")
      console.log("map:" + map)
      var pointPosition = new google.maps.LatLng(this.lat, this.lng);
      console.log(pointPosition)
      new google.maps.Marker({
        position: pointPosition,
        map: map,
        title: "This is a title"
      })
    }
  }
