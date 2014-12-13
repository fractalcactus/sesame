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
  }
}


        // var infowindow = new google.maps.InfoWindow({
        //   map: this.view.map,
        //   position: pos,
        //   content: "<a href='http://www.google.com'>Google!</a>"
        // });
