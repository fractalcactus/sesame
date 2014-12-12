function View(){

}
View.prototype = {
  renderOven: function(oven) {
    $(oven.ovenContents).each(function( index, batch ){
      if ($('#rack_0').html() == "[empty]") {
        $('#rack_0').html(this.batchType + " [" + this.cookieStatus() + "]")
      }
      else if ($('#rack_1').html() == "[empty]") {
        $('#rack_1').html(this.batchType + " [" + this.cookieStatus() + "]")
      }
      else if ($('#rack_2').html() == "[empty]") {
        $('#rack_2').html(this.batchType + " [" + this.cookieStatus() + "]")
      }
      else {
        alert("Oven is full!")
      }
    })
  }
}
