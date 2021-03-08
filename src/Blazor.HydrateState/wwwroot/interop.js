window.__hydrateState = function () {
    var state = {};

    function getState(name) {
        return state[name];
    }

    window.addEventListener('load', function (e) {
        state = JSON.parse(document.getElementById('hydrateState-data').text);
    });

    return {
        getState
    }
}();