// var checkLocation = function(pos) {

//   console.log(pos)

//   $.ajax({
//     type: "GET",
//     url: "/api/location",
//     data: { LatLng: pos }
//   })
//   .done(function( msg ) {
//     alert( "Data Saved: " + msg );
//   });
//   // .fail(function() {
//   //   alert( "ERROR ERROR BUT INSIDE THIS STUPID FUNCTION YAYA" );
//   // })
// }

// var renderMarkers = function() {
//   $.ajax({
//     type: "GET",
//     url: "/api/getallmarkers",
//   })
//   .done(function( array ) {
//     $(array).each(new PointMarker());
//   });
//   // .fail(function() {
//   //   alert( "ERROR ERROR BUT INSIDE THIS STUPID FUNCTION YAYA" );
//   // })
// }

// var PointMarker = function(lat, lng) {
//   this.lat = lat;
//   this.lng = lng;
//   this.markerLatlng = new google.maps.LatLng(lat, lng);
// }

// PointMarker.prototype = {
//   initialize: new google.maps.Marker({
//     position: this.markerLatLng,
//     map: map,
//     title: "This is a title"
//   });
// }
