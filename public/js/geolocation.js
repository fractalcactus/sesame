function Cookie(bakeTime, batchType){
  this.bakeTime = bakeTime;
  this.batchType = batchType;
  this.cookieStatusCode = 0;
}

Cookie.prototype = {
  bakeBatch: function() {
    this.cookieStatusCode ++;
  },
  cookieStatus: function() {
    if (this.cookieStatusCode == 0) {
      return "raw"
    }
    else if (this.cookieStatusCode < this.bakeTime) {
      return "gooey"
    }
    else if (this.cookieStatusCode == this.bakeTime) {
      return "just right"
    }
    else if (this.cookieStatusCode > this.bakeTime) {
      return "crispy"
    }
  }
}
