function View() {
  this.initializeMap();
}

View.prototype = {
  initializeMap: function() {
    var mapOptions = {
      center: {lat: -41.295291, lng: 174.773071},
      zoom: 18
    }
  this.map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions);
  },
  initializeUserMarker: function(pos) {
      this.userMarker = new google.maps.Marker({
      position: pos,
      map: this.map,
      title: "User Marker"
    })
  }
}


        // var infowindow = new google.maps.InfoWindow({
        //   map: this.view.map,
        //   position: pos,
        //   content: "<a href='http://www.google.com'>Google!</a>"
        // });