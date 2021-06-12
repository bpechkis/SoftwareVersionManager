var app = new Vue({
    el: "#softwareSearch",
    data: {
        softwares: [],
        versionsOlderThan: null,
        invalidFormat: false,
        error: null,
        loading: true
    },
    mounted: function () {
        this.searchVersions();
    },
    methods: {
        searchVersions: function () {
            this.softwares = [];
            this.loading = true;

            var url = "/api/Software";

            if (this.versionsOlderThan)
            {
                if (!/^[0-9]+(\.[0-9]+){0,2}$/.test(this.versionsOlderThan)) {
                    this.invalidFormat = true;
                    return;
                }
                else
                    this.invalidFormat = false;

                url += "?versionsOlderThan=" + this.versionsOlderThan;
            }

            axios
                .get(url)
                .then(function (response) {
                    this.error = null;
                    this.softwares = response.data;
                    this.loading = false;
                }.bind(this))
                .catch(function (errorMsg) {
                    this.error = errorMsg;
                    this.loading = false;
                }.bind(this));

            
        }
    }
})