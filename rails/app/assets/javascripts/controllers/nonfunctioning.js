// $(document).ready( function() {

//   var map;
//   function initialize() {
//     var mapOptions = {
//       center: { lat: -41.295291, lng: 174.773071},
//       zoom: 18
//     };

//     // Grabbing the map div to send the new position to
//     var map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions);

//     // Getting your current location if your browser allows it


//     function getLocationLoop(){
//         if(navigator.geolocation) {
//           navigator.geolocation.getCurrentPosition(function(position) {
//             var pos = new google.maps.LatLng(position.coords.latitude,
//                                            position.coords.longitude);

//         // Pops up info box with comment

//             var infowindow = new google.maps.InfoWindow({
//               map: map,
//               position: pos,
//               content: "www.youtube.com"
//             });

//         // Centers map on current position
//             checkLocation(pos);
//             map.setCenter(pos);

//         // Response if there is an error getting the geolocation

//           }, function() { handleNoGeolocation(true);});
//         }
//         else {

//         // Browser doesn't support Geolocation

//           handleNoGeolocation(false);
//         }
//     };

//     // function liveLocation(){
//     //   setInterval(function(){
//     //     getLocationLoop()
//     //   },1000);
//     // }

//   }

//   // Error flags if there is a problem

//   function handleNoGeolocation(errorFlag) {
//     if (errorFlag) {
//       var content = 'Error: The Geolocation service failed.';
//     } else {
//       var content = 'Error: Your browser doesn\'t support geolocation.';
//     }

//     var options = {
//       map: map,
//       position: new google.maps.LatLng(60, 105),
//       content: content
//     };

//     var infowindow = new google.maps.InfoWindow(options);
//     map.setCenter(options.position);
//   }

//   google.maps.event.addDomListener(window, 'load', initialize);

// })


