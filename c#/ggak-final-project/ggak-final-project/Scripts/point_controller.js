  function Controller() {
    this.view = new View();
    this.getUserLocation();
    this.getMarkers();
    this.positionRefresh();
    this.addListeners();
  }

  var global = this;
  var allMarkers = [];

  Controller.prototype = {
    addListeners: function() {
      var self = this;
      $("#drop").on('click', function(){
        self.newPoint();
      });
    },
    positionRefresh: function() {
      setInterval(function(){
        this.getUserLocation()
      }.bind(this), 5000);
    },
    getUserLocation: function() {
      if(navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(this.positionReponse.bind(this), this.positionError.bind(this))
      }
      else {
        handleNoGeolocation(false);
      }
    },
    positionReponse: function(position) {
      var pos = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);
      this.checkLocation(pos);
      this.moveUserMarker(pos);
    },
    moveUserMarker: function(pos) {
      if(this.view.userMarker) {
        this.view.userMarker.setPosition(pos);
      }
      else {
        this.view.initializeUserMarker(pos);
      }
    },
    positionError: function() {
      handleNoGeolocation(true);
    },
    // THis is what I need to fix in order to make it pop up with the marker that corresponds to the ajax response
    checkLocation: function(pos) {
        var self = this;
        var userLat = pos.lat();
        var userLng = pos.lng();
        $.ajax({
            type: "GET",
            //url: "api/WayPoints?lat="+userLat+"&lng="+userLng
            url: "api/WayPoints?lat=-41.3038673&lng=174.742126"
    })
        .done(function(response) {
          if (response.Id != 0) {
              self.findEnteredMarker(response.Id)
          };
        })
        .fail(function() {
            alert("Checking database failed");
        });
    },
    findEnteredMarker: function (id) {
        var pointId = id;
        var self = this;
        $.each(global.allMarkers, function (index, marker) {
            if (marker.title == pointId) {
                self.changeEnteredIcon(marker);
                self.openPoint(marker);
            }
        });
    },
    newPoint: function() {
      var self = this;
      var marker = this.view.addMarker();
      var latitude = marker.getPosition().lat();
      var longitude = marker.getPosition().lat();
      google.maps.event.addListener(marker, 'dragend', function (event) {
        latitude = marker.getPosition().lat();
        longitude = marker.getPosition().lng();
      });

      $("#save").on('click', function(){
        var point = {
          lat: latitude,
          lng: longitude,
          url: $("#enter-url").val(),
          id: 22
        };
        var savedMarker = new PointMarker(point);
        savedMarker.placeMarker(self.view.map)
        marker.setMap(null);
        // var saveMarker = self.view.addMarker(point);
        // saveMarker.placeMarker(self.view.map);
      });

      // $.each(markers, function(index, item) {
      //   var marker = new PointMarker(item)
      //   var googleMarker = marker.placeMarker(self.view.map);
      //   global.allMarkers.push(googleMarker)
      // })

    },
    changeEnteredIcon: function(enteredMarker) {
      enteredMarker.setIcon('http://www.broadwaybagels.ie/images/sesame.gif')
    },
    openPoint: function(enteredMarker) {
      var self = this;
      google.maps.event.clearListeners(enteredMarker, 'click');
      var clickListener = google.maps.event.addListener(enteredMarker, 'click', function() {
        var infowindow = new google.maps.InfoWindow({
          map: self.view.map,
          position: enteredMarker.position,
          content: "<a href='http://www.google.com'>Google!</a>"
        });
      });
    },
    retrieveMarkers: function(markers) {
        console.log("retrieve: ", markers)
      var self = this;
      $.each(markers, function(index, item) {
        var marker = new PointMarker(item);
        var googleMarker = marker.placeMarker(self.view.map);
        global.allMarkers.push(googleMarker);
      })
    },
    getMarkers: function () {
        var self = this;
        $.ajax({
            type: "GET",
            url: "api/WayPoints",
        })
        .done(function (response) {
                console.log("ajax :", response);
                self.retrieveMarkers(response);

            })
        .fail(function() {
            alert("ERROR ERROR BUT INSIDE THIS STUPID FUNCTION YAYA");
        });
      //  return JSON array
    },
  }


  //var markers = [
  //{id:1,lat:-41.292936, lng:174.778219},
  //{id:2,lat:-41.282786, lng:174.766310},
  //{id:3,lat:-41.303866, lng:174.742127},
  //{id:4,lat:-41.311305, lng:174.818388},
  //{id:5,lat:-41.278163, lng:174.777446}
  //]

        // renderMarkers();
        // map.setCenter(pos);

    // Response if there is an error getting the geolocation



    // Browser doesn't support Geolocation


  // // Error flags if there is a problem

  // function handleNoGeolocation(errorFlag) {
  //   if (errorFlag) {
  //     var content = 'Error: The Geolocation service failed.';
  //   } else {
  //     var content = 'Error: Your browser doesn\'t support geolocation.';
  //   }

  //   var options = {
  //     map: map,
  //     position: new google.maps.LatLng(60, 105),
  //     content: content
  //   };

  //   var infowindow = new google.maps.InfoWindow(options);
  //   map.setCenter(options.position);
  // }

  // var checkLocation = function(pos) {

  //   console.log(pos)

  //   // $.ajax({
  //   //   type: "GET",
  //   //   url: "/api/location",
  //   //   data: { LatLng: pos }
  //   // })
  //   // .done(function( msg ) {
  //   //   alert( "Data Saved: " + msg );
  //   // });
  //   // .fail(function() {
  //   //   alert( "ERROR ERROR BUT INSIDE THIS STUPID FUNCTION YAYA" );
  //   // })
  // }









// $.ajax({
//   type: "POST",
//   url: "/api/location",
//   data: { Lat: marker.position.lat, Lng: marker.position.lng, url: }
// })
// .done(function( msg ) {
//   alert( "Data Saved: " + msg );
// });
// .fail(function() {
//   alert( "ERROR ERROR BUT INSIDE THIS STUPID FUNCTION YAYA" );
// })