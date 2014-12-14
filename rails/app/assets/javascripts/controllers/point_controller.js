  function Controller() {
    this.view = new View();
    this.getUserLocation();
    this.retrieveMarkers();
    this.positionRefresh();
    this.addListeners();
    //added search
    this.search();
  }

  var global = this;

  Controller.prototype = {
    addListeners: function() {
      var self = this;
      // $("#drop").on('click', function(){
      //   self.newPoint();
      // });
      $("#bottom-navigation").on('click', "#submit-point" ,function(){
        self.newPoint();
        $("#bottom-navigation").html("<div id='content-link'><label name='url'>Content Link<label/><br><input name='url' type='text' id='enter-url'/><br><button id='save'>Save</button></div>")
      });

      $("#bottom-navigation").on('click', "#save", function(){
        //make sure this saves --- maybe split out save method?
        $("#bottom-navigation").html("<div id='submit-point'><button id='drop'>Add a Point</button></div>")});
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
        var infowindow = new google.maps.InfoWindow({
          map: self.view.map,
          position: enteredMarker.position,
          content: "<a href='http://www.google.com'>Google!</a>"
        });
      });
    },

    // openPoint: function(enteredMarker) {
    //   var self = this;
    //   google.maps.event.clearListeners(enteredMarker, 'click');

    //   var infowindow = new google.maps.InfoWindow({
    //     map: self.view.map,
    //     position: enteredMarker.position,
    //     content: "<a href='http://www.google.com'>Google!</a>",
    //     disableAutoPan: true
    //   });

    //   google.maps.event.addListener(enteredMarker, 'click', function() {
    //     console.log(infowindow + " hereherheh")
    //     infowindow.open(self.view.map, enteredMarker)
    //   });
    // },

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

    search: function() {

      var self = this;
      var markers = [];
      var input = (document.getElementById('pac-input'));
      self.view.map.controls[google.maps.ControlPosition.TOP_LEFT].push(input);

      var searchBox = new google.maps.places.SearchBox(input);

      google.maps.event.addListener(searchBox, 'places_changed', function() {
        var places = searchBox.getPlaces();

        if (places.length == 0) {
          return;
        }
        for (var i = 0, marker; marker = markers[i]; i++) {
          marker.setMap(null);
        }

        markers = [];
        var bounds = new google.maps.LatLngBounds();
        for (var i = 0, place; place = places[i]; i++) {
          var image = {
            url: place.icon,
            size: new google.maps.Size(71, 71),
            origin: new google.maps.Point(0, 0),
            anchor: new google.maps.Point(17, 34),
            scaledSize: new google.maps.Size(25, 25)
          };

          var marker = new google.maps.Marker({
            map: self.view.map,
            icon: image,
            title: place.name,
            position: place.geometry.location
          });

          markers.push(marker);

          bounds.extend(place.geometry.location);
        }

        self.view.map.fitBounds(bounds);
      });

      google.maps.event.addListener(self.view.map, 'bounds_changed', function() {
        var bounds = self.view.map.getBounds();
        searchBox.setBounds(bounds);
      });
      }

  }

  var allMarkers = []

  var markers = [
  {id:1,lat:-41.292936, lng:174.778219},
  {id:2,lat:-41.282786, lng:174.766310},
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




