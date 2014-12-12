var Controller = function(){
  this.self = this;
}

Controller.prototype = {
  getLocation: function() {
      navigator.geolocation.getCurrentPosition(showPosition);
  },
  showPosition: function(position) {
      console.log("argh")
      x.innerHTML = "Latitude: " + position.coords.latitude +
      "<br>Longitude: " + position.coords.longitude;
  }
}
