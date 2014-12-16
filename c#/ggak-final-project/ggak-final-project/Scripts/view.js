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
  },
    addPopup: function(enteredMarker) {
        var content;
        var self = this;
        if (enteredMarker.content.match(/(soundcloud)/i)) {
            content = "<div class='info-window'><a href='" + enteredMarker.content + "'><img width='50px' src='https://dl-web.dropbox.com/get/play.svg?_subject_uid=126418071&w=AAD4DNBzmDMykdT1LooMbHoZG6x7rJip3lXxSoBxLgLPEA'/><p>Play Song</p></a></div>"
        }
        else if (enteredMarker.content.match(/(youtube)/i)) {
            content = "<div class='info-window'><a href='" + enteredMarker.content + "'><img  width='50px' src='https://dl-web.dropbox.com/get/play.svg?_subject_uid=126418071&w=AAD4DNBzmDMykdT1LooMbHoZG6x7rJip3lXxSoBxLgLPEA'/><p>Play Video</p></a></div>"
            console.log(content);
        }
        else if ((enteredMarker.content.match(/(http)/i)) || (enteredMarker.url.match(/(www)/i))) {
            content = "<div class='info-window'><a href='" + enteredMarker.content + "'><p>Follow Link</p></a></div>"
        }
        else {
            content = "<p>" + enteredMarker.content + "</p>"
        }
        var infowindow = new google.maps.InfoWindow({
            map: self.map,
            position: enteredMarker.getPosition(),
            content: content
        });
    }
}