(function($){
  $(function(){
      $('.parallax').parallax();
      $('.dropdown-button').dropdown({
          inDuration: 300,
          outDuration: 225,
          hover: true,
          belowOrigin: true,
          alignment: 'left'
      });
      $(".button-collapse").sideNav({
          edge: 'right',
          closeOnClick: false,
          draggable: false
      });
  });
})(jQuery);