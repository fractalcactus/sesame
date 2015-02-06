function View() {
  this.initializeMap();
}

View.prototype = {
  // Map initializes zoomed out, looking at NZ
  initializeMap: function() {
    var mapOptions = {
      center: {lat: -43.52853067061281, lng: 173.184561225},
      zoom: 5,
      mapTypeControl: false,
      panControl: false,
      zoomControl: false,
      streetViewControl: false,
    }
  this.map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions);
  this.getInitialLocation();
  },
  // Map zooms in to user location
  getInitialLocation: function() {
    var self = this;
    navigator.geolocation.getCurrentPosition(function(position) {
      self.map.panTo({ lat: position.coords.latitude, lng: position.coords.longitude });
      self.map.setZoom(18);
    });
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
      var marker = new google.maps.Marker({
        position: self.map.getCenter(),
        map: self.map,
        draggable: true,
        animation: google.maps.Animation.DROP,
      title:"This a new marker!",
      icon: "/Content/newmarker.svg"
    });
  return marker;
  },
  addPopup: function (enteredMarker) {
      var content = enteredMarker.content ? enteredMarker.content : 'There is no content to display';
        var self = this;
        if (content.match(/(soundcloud)/i)) {
            content = "<div class='info-window'><a href='" + content + "'><img width='50px' src='/Content/play.svg'/><p>Play Song</p></a></div>"
        }
        else if (content.match(/(youtu)/i)) {
            content = "<div class='info-window'><a href='" + content + "'><img  width='50px' src='/Content/play.svg'/><p>Play Video</p></a></div>"
        }
        else if ((content.match(/(http)/i)) || (content.match(/(www)/i))) {
            content = "<div class='info-window'><a href='" + content + "'><p>Follow Link</p></a></div>"
        }
        else {
            content = "<div class='info-window'><p>" + content + "</p></div>";
        }
        new google.maps.InfoWindow({
            map: self.map,
            position: enteredMarker.getPosition(),
            content: content
        });
    },
  generateShareLink: function (point) {
        var link = "worldplayground.azurewebsites.net/?id=" + point.point_id
        $("#success-message").html("Share this link: " + link)
    }
}