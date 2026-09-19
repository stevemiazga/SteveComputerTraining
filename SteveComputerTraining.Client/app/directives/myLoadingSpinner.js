//http://ankursethi.in/2013/07/loading-spinners-with-angularjs-and-spin-js/
angular.module('ComputerTrainingApp')
  .directive('myLoadingSpinner', function () {
      return {
          restrict: 'A',
          replace: true,
          transclude: true,
          scope: {
              loading: '=myLoadingSpinner'
          },
          templateUrl: 'app/directives/loading.html',
          link: function (scope, element, attrs) {
              var spinner = new Spinner().spin();
              var loadingContainer = element.find('.my-loading-spinner-container')[0];
              //var loadingContainer = element.find('my-loading-spinner-container')[0];
              loadingContainer.appendChild(spinner.el);
          }
      };
  });