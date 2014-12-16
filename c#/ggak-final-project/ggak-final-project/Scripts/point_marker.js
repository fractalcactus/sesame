var PointMarker = function (item) {
    this.lat = parseFloat(item.Latitude);
    this.lng = parseFloat(item.Longitude);
    this.point_id = parseFloat(item.Id);
    this.url = item.URL;
}
  PointMarker.prototype = {
    placeMarker: function(map) {
      var pointPosition = new google.maps.LatLng(this.lat, this.lng);
      var string = String(this.point_id);
        var newMarker = new google.maps.Marker({
            position: pointPosition,
            map: map,
            title: string,
            icon: "/Content/fixedmarker.svg",
            content: this.url
        });
        return newMarker;
    }
  }
