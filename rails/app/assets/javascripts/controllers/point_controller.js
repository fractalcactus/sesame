$(document).ready( function() {
  // function pointController = () {
  //   this.map
  // }
  // var self = this;

  var map;
  function initialize() {
    var mapOptions = {
      center: {lat: -41.295291, lng: 174.773071},
      zoom: 18
    };

    // Grabbing the map div to send the new position to

    map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions);

    // renderMarkers();

    // Getting your current location if your browser allows it

    if(navigator.geolocation) {
      navigator.geolocation.getCurrentPosition(function(position) {
        var pos = new google.maps.LatLng(position.coords.latitude,
                                       position.coords.longitude);

    // Pops up info box with comment

        var infowindow = new google.maps.InfoWindow({
          map: map,
          position: pos,
          content: "www.youtube.com"
        });

    // Centers map on current position
        checkLocation(pos);
        renderMarkers();
        map.setCenter(pos);

    // Response if there is an error getting the geolocation

      }, function() { handleNoGeolocation(true);});
    }
    else {

    // Browser doesn't support Geolocation

      handleNoGeolocation(false);
    }
    function addMarker() { //function that will add markers on button click
      var mapCenter = new google.maps.LatLng(-41.295291, 174.773071);
      var marker = new google.maps.Marker({
          position: mapCenter,
          map: map,
            draggable:true,
            animation: google.maps.Animation.DROP,
          title:"This a new marker!",
        icon: "http://maps.google.com/mapfiles/ms/micons/blue.png"
      });

      // $.ajax({
      //   type: "POST",
      //   url: "/api/location",
      //   data: { LatLng: pos }
      // })
      // .done(function( msg ) {
      //   alert( "Data Saved: " + msg );
      // });
      // .fail(function() {
      //   alert( "ERROR ERROR BUT INSIDE THIS STUPID FUNCTION YAYA" );
      // })

    }
    $("#drop").on('click', addMarker());
  }

  // Error flags if there is a problem

  function handleNoGeolocation(errorFlag) {
    if (errorFlag) {
      var content = 'Error: The Geolocation service failed.';
    } else {
      var content = 'Error: Your browser doesn\'t support geolocation.';
    }

    var options = {
      map: map,
      position: new google.maps.LatLng(60, 105),
      content: content
    };

    var infowindow = new google.maps.InfoWindow(options);
    map.setCenter(options.position);
  }

  var checkLocation = function(pos) {

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
  }

  var renderMarkers = function() {
    console.log("rendering markers")
    var newMarker = new PointMarker(174.77309259999993, -41.2952786);
    newMarker.placeMarker();
    // $.ajax({
    //   type: "GET",
    //   url: "/api/getallmarkers",
    // })
    // .done(function( array ) {
    //   $(array).each(new PointMarker());
    // });
    // .fail(function() {
    //   alert( "ERROR ERROR BUT INSIDE THIS STUPID FUNCTION YAYA" );
    // })
  }

  var PointMarker = function(lat, lng) {
    this.lat = lat;
    this.lng = lng;
  }

  PointMarker.prototype = {
    placeMarker: function() {
      console.log("Inside placing marker")
      console.log("map:" + map)
      var centralPark = new google.maps.LatLng(37.7699298, -122.4469157);
      console.log(centralPark)
      new google.maps.Marker({
        position: centralPark,
        map: map,
        title: "This is a title"
      })
    }
  }

  google.maps.event.addDomListener(window, 'load', initialize);

})


