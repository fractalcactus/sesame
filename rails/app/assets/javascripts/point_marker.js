  var PointMarker = function(item) {
    this.lat = item.lat;
    this.lng = item.lng;
    this.point_id = item.id;
    this.url = item.url
  }
  PointMarker.prototype = {
    placeMarker: function(map) {
      console.log("Inside placing marker")
      console.log("map:" + map)
      var pointPosition = new google.maps.LatLng(this.lat, this.lng);
      console.log(pointPosition)
      var string = String(this.point_id);
      var newMarker = new google.maps.Marker({
        position: pointPosition,
        map: map,
        title: string,
        content: this.url
      })
    return newMarker    }
  }
