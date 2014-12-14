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
      title: "User Marker",
      icon: 'http://i.imgur.com/usnngl1.png'
    })
  },
  addMarker: function() {
  var self = this;
  var marker = new google.maps.Marker({
    //changed get center 2 adjust
      position: self.map.getCenter(),
      map: self.map,
        draggable: true,
        animation: google.maps.Animation.DROP,
      title:"This a new marker!",
    icon: "http://maps.google.com/mapfiles/ms/micons/blue.png"
    });
  return marker;
  }
}
