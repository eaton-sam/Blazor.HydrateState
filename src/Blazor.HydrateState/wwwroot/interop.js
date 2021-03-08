//let __hydrateState_state = {};

//window.addEventListener('load', function (e) {
//    __hydrateState_state = JSON.parse(document.getElementById('hydrateState-data').text);
//});

//function __hydrateState_getState(name) {
//    return __hydrateState_state[name];
//}

//window.__hydrateState = {
//    state = {},
//    getState: function (name) {
//        return this.state[name];
//    },
//    register: function () {
//        window.addEventListener('load', function (e) {
//            this.state = JSON.parse(document.getElementById('hydrateState-data').text);
//        });
//    }
//}

//window.__hydrateState.register();


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