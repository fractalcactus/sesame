var Controller = function(){
  this.self = this;
}

Controller.prototype = {
  initialize: function() {
    navigator.geolocation.getCurrentPosition(this.self.showPosition(position))
  },
  showPosition: function(position) {
    console.log("show pos")
    console.log(position.coords.latitude)
  }
}

