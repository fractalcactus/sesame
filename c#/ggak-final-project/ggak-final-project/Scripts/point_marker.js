var PointMarker = function (item) {
    console.log(item)
    this.lat = parseFloat(item.Lat);
    this.lng = parseFloat(item.Lng);
    this.point_id = parseFloat(item.Id);
    this.url = item.URL
  }
  PointMarker.prototype = {
    placeMarker: function(map) {
      console.log("Inside placing marker")
      var pointPosition = new google.maps.LatLng(this.lat, this.lng);
      console.log(pointPosition)
      var string = String(this.point_id);
        var newMarker = new google.maps.Marker({
            position: pointPosition,
            map: map,
            title: string
        });
        return newMarker;
    }
  }
