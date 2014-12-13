  function Controller() {
    this.view = new View();
    this.getUserLocation();
    this.retrieveMarkers();
  }

  Controller.prototype = {
    positionRefresh: function() {
      setTimeout(console.log("Location"), 5000);
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
    },
    positionError: function() {
      handleNoGeolocation(true);
    },
    checkLocation: function(pos) {
      console.log(pos)
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
    },
    retrieveMarkers: function() {
      // var markers = getMarkers();
      var self = this;
      $.each(markers, function(index, item) {
        var marker = new PointMarker(item)
        marker.placeMarker(self.view.map);
      })
    }

  }

        // renderMarkers();
        // map.setCenter(pos);

    // Response if there is an error getting the geolocation



    // Browser doesn't support Geolocation


  //   function addMarker() { //function that will add markers on button click
  //     var mapCenter = new google.maps.LatLng(-41.295291, 174.773071);
  //     var marker = new google.maps.Marker({
  //         position: mapCenter,
  //         map: map,
  //           draggable:true,
  //           animation: google.maps.Animation.DROP,
  //         title:"This a new marker!",
  //       icon: "http://maps.google.com/mapfiles/ms/micons/blue.png"
  //     });

  //     // $.ajax({
  //     //   type: "POST",
  //     //   url: "/api/location",
  //     //   data: { LatLng: pos }
  //     // })
  //     // .done(function( msg ) {
  //     //   alert( "Data Saved: " + msg );
  //     // });
  //     // .fail(function() {
  //     //   alert( "ERROR ERROR BUT INSIDE THIS STUPID FUNCTION YAYA" );
  //     // })

  //   }
  //   $("#drop").on('click', addMarker());
  // }

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




