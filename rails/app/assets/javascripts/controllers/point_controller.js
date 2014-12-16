  function Controller() {
    this.view = new View();
    this.getUserLocation();
    this.retrieveMarkers();
    this.positionRefresh();
    this.addListeners();
  }

  var global = this;

  Controller.prototype = {
    addListeners: function () {
      var self = this;
      $("#submit-point").on('click', function () {
          self.newPoint();
          $(this).slideToggle();
          $("#content-link").slideToggle();
      });
      $("#save").on('click', function () {
          $("#content-link").slideToggle();
          $("#submit-point").slideToggle();
          self.savePoint(draggablePoint);
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
      var response = {
        id: 2,
        url: "A url!",
      }
      $.each(allMarkers, function (index, marker) {
        if(marker.title == String(response.id)) {
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
          id: 23
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


    // $.ajax({
    //   type: "GET",
    //   url: "/api/location",
    //   data: { LatLng: pos }
    // })
    // .done(function( msg ) {
    //   alert( "Data Saved: " + msg );
    // });
    // .fail(function() {
    //   alert( "ERROR ERROR BUT INSIDE THIS STUPID FUNCTION YAYA" );
    // })
    changeEnteredIcon: function(enteredMarker) {
      enteredMarker.setIcon('http://www.broadwaybagels.ie/images/sesame.gif')
    },
    openPoint: function(enteredMarker) {
      var self = this;
      google.maps.event.clearListeners(enteredMarker, 'click');
      var clickListener = google.maps.event.addListener(enteredMarker, 'click', function() {
        self.view.addPopup(enteredMarker)
      })
    },

    retrieveMarkers: function() {
      // var markers = getMarkers();
      var self = this;
      $.each(markers, function(index, item) {
        var marker = new PointMarker(item)
        var googleMarker = marker.placeMarker(self.view.map);
        global.allMarkers.push(googleMarker)
      })
    },


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
  }

  var allMarkers = []

  var markers = [
  {id:1,lat:-41.292936, lng:174.778219},
  {id:2,lat:-41.282786, lng:174.766310, url: "https://www.youtube.com/watch?v=syFZfO_wfMQ"},
  {id:3,lat:-41.303866, lng:174.742127},
  {id:4,lat:-41.311305, lng:174.818388},
  {id:5,lat:-41.278163, lng:174.777446}
  ]

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

  // var getMarkers = function() {
  //   // $.ajax({
  //   //   type: "GET",
  //   //   url: "/api/getallmarkers",
  //   // })
  //   // .done(function( array ) {
  //   //   $(array).each(new PointMarker());
  //   // });
  //   // .fail(function() {
  //   //   alert( "ERROR ERROR BUT INSIDE THIS STUPID FUNCTION YAYA" );
  //   // })
    // return JSON array
  // }




