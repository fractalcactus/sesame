function View() {
  this.initializeMap();
}

View.prototype = {
  initializeMap: function() {
    var mapOptions = {
      center: {lat: -41.295291, lng: 174.773071},
      zoom: 18,
      mapTypeControl: false,
      panControl: false,
      zoomControl: false,
      streetViewControl: false,
    }
  this.map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions);
  },
  initializeUserMarker: function(pos) {
      this.userMarker = new google.maps.Marker({
      position: pos,
      map: this.map,
      title: "User Marker",
      icon: "/Content/usermarker.svg"
    })
  },
  addMarker: function() {
      var self = this;
      console.log(self.map.getCenter());
      var marker = new google.maps.Marker({
        position: self.map.getCenter(),
        map: self.map,
        draggable: true,
        animation: google.maps.Animation.DROP,
      title:"This a new marker!",
      icon: "/Content/newmarker.svg"
    });
  return marker;
  }
}