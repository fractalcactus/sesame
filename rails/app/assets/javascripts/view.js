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
      icon: 'https://dl-web.dropbox.com/get/usermarker.svg?_subject_uid=126418071&w=AAA8MFbGdXKz7uxAqtk-KSfyog3MSdBTcRbxSi_3wQCGAg'
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
    icon: "https://dl-web.dropbox.com/get/newmarker.svg?_subject_uid=126418071&w=AADU0U33XDfNPO9BlFx17dz_S_DCBD4s144_aOjGiNaWVA"
    });
  return marker;
  }
}
