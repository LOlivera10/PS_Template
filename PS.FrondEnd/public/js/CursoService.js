import * as Constant from "./Constant.js"

const GetCursoById = (id) => {
    let url = Constant.default + id;
    return fetch(url, {
        method:"GET",
        headers: {
            "Authorization": "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFkbWluIiwiZW1haWwiOiJBZG1pbkBtYWlsLmNvbSIsInJvbGUiOiJBZG1pbiIsIm5iZiI6MTYwMjgwMjExOCwiZXhwIjoxNjAyODA1NzE4LCJpYXQiOjE2MDI4MDIxMTh9.Cy0UyXlnqY-s58VHL4MQOSeKGDvri4j7a0Ue4PZM7u4"
        }
    })
            .then(response => { 
                console.log(response);
                return response.json()
            })
            .then(json => {
                console.log(json);
                return json;
            })
            .catch(err => console.log('ERROR: ' + err))
}

export default GetCursoById;