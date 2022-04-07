const CONFIG = require('../../../jsconfig.json');

export const SeasonsGET = async () => {

    class Season {
        constructor(id, title) {
            this.Id = id;
            this.Title = title;
        }
    }

    const response = await fetch(CONFIG["server"] + CONFIG.requests.GET["seasons"]);
    if (response.ok) {
        let json = await response.json();
        const data = json.seasons;

        let Seasons = [];
        Seasons = data.map((season) => {
            if (season) return new Season(season.id, season.title);
            else throw new Error('Failed to operate seasons');
        });

        return Seasons;

    } else {
        let json = await response.json();
        console.log(json.errorMessage);
    }


}