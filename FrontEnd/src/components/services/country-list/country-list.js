import React from "react";

const data = [
    {
        "id": "79065b08-e92c-461a-9101-2d3809953a7e",
        "name": "Poland"
    },
    {
        "id": "557b1e11-d60c-44b0-98f6-6252aad55a36",
        "name": "Portugal"
    },
    {
        "id": "bf4672aa-c977-40db-acc3-11d604c674d9",
        "name": "Russian Federation"
    },
    {
        "id": "fe02e309-310b-412e-988d-ea859a5cd322",
        "name": "Qatar"
    },
    {
        "id": "55026861-b6c2-4b7a-b604-7d8a81065caf",
        "name": "Pakistan"
    },
    {
        "id": "8e186ed6-dbf7-4b0f-87df-8104ef50c905",
        "name": "Namibia"
    },
    {
        "id": "44453a8c-9e05-4545-9b95-2cf5f280e642",
        "name": "Malawi"
    },
    {
        "id": "6b9a6474-070e-4657-9d7b-854bb5a45a45",
        "name": "Mozambique"
    },
    {
        "id": "03386d98-af97-4555-a48d-d82d18dc037d",
        "name": "Liechtenstein"
    },
    {
        "id": "421f8ce9-f76a-4cec-8c14-31be18f3b314",
        "name": "Libya"
    },
    {
        "id": "7a40b54f-31e7-4fa0-8e22-214f16ddf184",
        "name": "Rwanda"
    },
    {
        "id": "0e575dde-2f37-4b03-be95-62b4cb8a1bb4",
        "name": "Lithuania"
    },
    {
        "id": "8db24d9f-4f99-4315-b22f-fd965a6c2d58",
        "name": "Luxembourg"
    },
    {
        "id": "c822103f-3bc5-4cf4-b0ab-73c63b4b19f5",
        "name": "Macedonia"
    },
    {
        "id": "c30646c5-6c68-4e53-942b-0d394075ff9e",
        "name": "Madagascar"
    },
    {
        "id": "4129d1cc-46af-4c9c-82d4-18a9d6066c2b",
        "name": "Malaysia"
    },
    {
        "id": "42b6d9a7-51cd-4c37-9a1a-7689abdfb6f9",
        "name": "Mali"
    },
    {
        "id": "39a7fbca-4e65-40eb-8852-58f710145e2c",
        "name": "Malta"
    },
    {
        "id": "59303215-b1ea-4d35-97c3-18d23728a838",
        "name": "Marshall Islands"
    },
    {
        "id": "f911b10e-f291-46f8-b94e-9fc362a1e799",
        "name": "Mauritania"
    },
    {
        "id": "c1c8d59e-d4de-428e-8bea-37a1f3665d91",
        "name": "Mauritius"
    },
    {
        "id": "22baa6fd-22e8-4d35-afb4-a39f3564c05c",
        "name": "Mexico"
    },
    {
        "id": "26a7ffe7-97b4-4d00-baab-66aa4d7ce07f",
        "name": "Micronesia"
    },
    {
        "id": "f35ff33e-7d06-4195-8e7c-cea4b83586ec",
        "name": "Moldova"
    },
    {
        "id": "e3c47134-2708-479d-9e92-30df56734776",
        "name": "Monaco"
    },
    {
        "id": "bfc19e93-56e6-4404-a27e-3d2b0b3bdc56",
        "name": "Mongolia"
    },
    {
        "id": "9a429833-00c8-42cd-a7a9-fcd0998635bc",
        "name": "Montenegro"
    },
    {
        "id": "325d6a2d-8c26-4754-871a-a17bf291b13c",
        "name": "Morocco"
    },
    {
        "id": "14834924-ef44-4303-8b59-0e78218324c0",
        "name": "Myanmar, {Burma}"
    },
    {
        "id": "e0f16c31-803c-4366-acc3-5fd4d3bbde74",
        "name": "Tanzania"
    },
    {
        "id": "a27a1a66-157c-4f46-88fc-9dfbee16f476",
        "name": "Thailand"
    },
    {
        "id": "2ea59e77-5c61-47c0-8378-efdc46eadaea",
        "name": "Togo"
    },
    {
        "id": "990e154a-7ddb-474d-b324-1fad00090cb3",
        "name": "Tonga"
    },
    {
        "id": "78f40c1a-2d75-4a3f-ade9-8e7b6ea41c40",
        "name": "Trinidad & Tobago"
    },
    {
        "id": "eb339c30-8749-4325-868c-417452cc1f72",
        "name": "Tunisia"
    },
    {
        "id": "9a8c5b01-6dce-4901-8500-e36b00abafac",
        "name": "Nigeria"
    },
    {
        "id": "757ff560-66b0-4095-bd5b-d1e76f9499a5",
        "name": "Turkmenistan"
    },
    {
        "id": "a033f742-ea2e-4ade-8f31-83cd85dcca8e",
        "name": "Niger"
    },
    {
        "id": "7f522080-c7aa-4ef7-9446-5beeb821fb72",
        "name": "Tuvalu"
    },
    {
        "id": "78eac296-3cba-424f-b842-88a69bd4b262",
        "name": "Ukraine"
    },
    {
        "id": "94b02259-8f1c-4086-8a2d-75f92713ba34",
        "name": "New Zealand"
    },
    {
        "id": "f97c010d-d3e2-4ba8-b947-02f5a4832f84",
        "name": "St Kitts & Nevis"
    },
    {
        "id": "81a198f9-4a38-4170-8e3a-5261d9e652d6",
        "name": "United Arab Emirates"
    },
    {
        "id": "c6bb764a-7153-4418-b507-ce5b90675284",
        "name": "Netherlands"
    },
    {
        "id": "f90ea3ae-7ba7-49e7-936b-c73adb641f6f",
        "name": "United Kingdom"
    },
    {
        "id": "4a62912e-d572-4f96-9364-7ed1f42a4fab",
        "name": "Oman"
    },
    {
        "id": "23fad4aa-1bbc-4753-97ad-bc7db88ef59d",
        "name": "Vatican City"
    },
    {
        "id": "6db1bd74-d578-4063-8259-e169a0c21fa8",
        "name": "Uruguay"
    },
    {
        "id": "a3600395-8695-4376-9ab3-23abb492476b",
        "name": "Venezuela"
    },
    {
        "id": "5fb65f40-bedb-433d-b1b6-49c52b193156",
        "name": "Romania"
    },
    {
        "id": "bb2d246a-6f55-44ed-aa8e-f03a740384e1",
        "name": "Vietnam"
    },
    {
        "id": "c4670c43-8558-47cf-ba42-ce94fac3b596",
        "name": "Philippines"
    },
    {
        "id": "c92313b6-0b56-4535-8439-a52ffedfff62",
        "name": "Liberia"
    },
    {
        "id": "b38d2c2a-e353-4941-908d-7ec78b684c63",
        "name": "Palau"
    },
    {
        "id": "5ae7440e-38b9-4cf7-ac47-7828afef2f5d",
        "name": "Yemen"
    },
    {
        "id": "b1ddcc3f-4bc4-44f5-8cfd-da9a74b557f5",
        "name": "Panama"
    },
    {
        "id": "f2d391fa-155c-42c1-9230-d4dcc8258fe3",
        "name": "Singapore"
    },
    {
        "id": "03bf0339-c50e-48f7-a789-b7406debb71a",
        "name": "Tajikistan"
    },
    {
        "id": "48fa65d4-b04b-494d-9256-b4a192976002",
        "name": "Papua New Guinea"
    },
    {
        "id": "58a64cea-3d84-40ef-ba08-06bd316f8c87",
        "name": "St Lucia"
    },
    {
        "id": "3c742c9b-4423-45a7-a572-ffdf9e2b0404",
        "name": "Taiwan"
    },
    {
        "id": "f65becb1-8497-4ba9-981d-fbd74a8a2b89",
        "name": "Saint Vincent & the Grenadines"
    },
    {
        "id": "24fb8dcb-8bd8-4bd6-baa7-d6aab707df4f",
        "name": "Solomon Islands"
    },
    {
        "id": "b95b814e-1539-4e78-817d-99b088a9a041",
        "name": "Switzerland"
    },
    {
        "id": "e0631745-44bd-44b8-b9e4-3bd26433e361",
        "name": "Somalia"
    },
    {
        "id": "a6912151-812b-4d8e-94cd-cda0d5504294",
        "name": "South Africa"
    },
    {
        "id": "cbb45fc6-a286-4a78-b8ad-634cbcbeca11",
        "name": "Latvia"
    },
    {
        "id": "84daef4b-7945-478d-aa61-3e396ec85b9d",
        "name": "South Sudan"
    },
    {
        "id": "3b96ad8e-6204-4d0c-8d24-bb88667d68d2",
        "name": "Serbia"
    },
    {
        "id": "26886880-8d0c-4aba-9c01-07252da30b27",
        "name": "Spain"
    },
    {
        "id": "34044ff3-c3d1-49e6-9ef0-22a6cf86bb38",
        "name": "Congo"
    },
    {
        "id": "491af97b-ac3d-4979-b771-4387147ec832",
        "name": "Cuba"
    },
    {
        "id": "6c4c31b7-0811-4a10-9cc0-5f7ea55539dc",
        "name": "Cyprus"
    },
    {
        "id": "493c5317-f6cd-4d84-b95b-c32a26ffbd95",
        "name": "Czech Republic"
    },
    {
        "id": "aff1f064-37fe-4a57-bfe2-a4fa3f9e581c",
        "name": "Costa Rica"
    },
    {
        "id": "05d5e37b-7323-4251-a89b-ebe2682e30bc",
        "name": "Sudan"
    },
    {
        "id": "7021da16-8d58-440a-a5df-a2039249c790",
        "name": "China"
    },
    {
        "id": "370f2a44-2345-4013-ada3-7cff9b927744",
        "name": "Croatia"
    },
    {
        "id": "c7973629-3edb-42de-b622-4504da529d49",
        "name": "Brazil"
    },
    {
        "id": "c7187547-501f-4726-946a-c0818119ad42",
        "name": "Suriname"
    },
    {
        "id": "fb43d3d2-c003-4385-a07f-aa0ed0abe694",
        "name": "Botswana"
    },
    {
        "id": "acb8bfbd-546f-4a45-9b8e-a2fdff96c676",
        "name": "Bosnia Herzegovina"
    },
    {
        "id": "cebbe1b1-6ffa-418f-9a5a-41ed3cabbcbe",
        "name": "Antigua & Deps"
    },
    {
        "id": "cad285bd-5a88-4352-bac9-59c42aa913b2",
        "name": "Swaziland"
    },
    {
        "id": "35b6cf72-11d0-4ee0-b8e5-76f21850d9ac",
        "name": "Argentina"
    },
    {
        "id": "f4087e3d-f70b-4711-ac5c-21f06fb4304e",
        "name": "Afghanistan"
    },
    {
        "id": "1afe01f8-69af-4ccb-96b3-75db82c0783a",
        "name": "Canada"
    },
    {
        "id": "1fef1cba-af0b-4603-b2a9-7da9fb0bb6d8",
        "name": "Armenia"
    },
    {
        "id": "694bf99a-d301-4494-a73c-86f190206339",
        "name": "Cape Verde"
    },
    {
        "id": "ac2204a1-7ee1-491c-9a3f-789ad1c6693a",
        "name": "Algeria"
    },
    {
        "id": "dfadcfa3-4813-46e2-a834-69c7d2d75cee",
        "name": "Australia"
    },
    {
        "id": "e1f70323-0aee-46f6-8802-aa85077783d6",
        "name": "Andorra"
    },
    {
        "id": "0ba16e08-e32a-4d4a-9d86-855f625d9c6d",
        "name": "Austria"
    },
    {
        "id": "3ac2d09a-3d62-4e77-9848-11f791aa255f",
        "name": "Bahrain"
    },
    {
        "id": "574fc58b-ac36-4c37-bfc5-f185aeb592c9",
        "name": "Chad"
    },
    {
        "id": "052841b9-964a-45c2-9752-f9717e169a45",
        "name": "Azerbaijan"
    },
    {
        "id": "3c191982-66fc-4c33-85cd-c3a22585346d",
        "name": "Bangladesh"
    },
    {
        "id": "651ede2c-6116-47dc-b465-2ac096347162",
        "name": "Brunei"
    },
    {
        "id": "572b7297-2f66-40de-b7b1-3cb2bb46576e",
        "name": "Bahamas"
    },
    {
        "id": "3fa1a73c-fa52-4571-a027-e424a8fba8e7",
        "name": "Dominica"
    },
    {
        "id": "0480af18-cb55-4246-8919-93dda0525116",
        "name": "Barbados"
    },
    {
        "id": "fb168824-dbc9-49a2-ad47-ee62f4fe06cf",
        "name": "Vanuatu"
    },
    {
        "id": "1f09a1c3-c96b-4441-8c13-4b90b781a6a9",
        "name": "Belarus"
    },
    {
        "id": "f25ab6e0-856d-46b5-8744-6b1e0b827677",
        "name": "Kenya"
    },
    {
        "id": "5b688527-8648-4be0-b5ce-8760afe6ea2c",
        "name": "Colombia"
    },
    {
        "id": "8219a358-0ca9-4daa-a968-e755a8589ab3",
        "name": "Dominican Republic"
    },
    {
        "id": "d03fdbe1-1300-45d5-97a9-49adc14fe1d8",
        "name": "Kiribati"
    },
    {
        "id": "aec6fd31-a73b-4226-a401-f2b2f7e4b4fe",
        "name": "Comoros"
    },
    {
        "id": "eaaae1ec-bf48-4a60-878b-193621eeda7d",
        "name": "Iceland"
    },
    {
        "id": "d8652f43-0885-4cac-98a3-07690f487f98",
        "name": "Benin"
    },
    {
        "id": "be675adb-248c-4357-806a-6ca384f05b1f",
        "name": "Korea North"
    },
    {
        "id": "23f07e0f-46d2-40d9-94d5-581e4820ac10",
        "name": "India"
    },
    {
        "id": "09a03686-958b-4005-8cad-0bc1c6ad85f1",
        "name": "Korea South"
    },
    {
        "id": "5a62d789-4b8a-4028-97c8-eafe20132459",
        "name": "Equatorial Guinea"
    },
    {
        "id": "d2fc1e70-64c2-4a16-a9e5-8a74c04f4148",
        "name": "Kosovo"
    },
    {
        "id": "ec09383e-2127-4c7c-a415-6ded277b7683",
        "name": "Denmark"
    },
    {
        "id": "67bdf750-3718-4568-ba91-4e2481fad56d",
        "name": "Iran"
    },
    {
        "id": "9da1b6c9-5684-4250-8789-4d851b1c1936",
        "name": "Eritrea"
    },
    {
        "id": "fe46eb33-2da2-4f34-b2af-61d26aff11b1",
        "name": "Kuwait"
    },
    {
        "id": "68e2b1f2-adbe-4e08-aed2-dfdc14e39fe8",
        "name": "Iraq"
    },
    {
        "id": "c3f13e3f-ce56-4674-a59d-32121db64d36",
        "name": "Guinea-Bissau"
    },
    {
        "id": "b333ec78-4429-4e4a-8675-3f1c55ea15ed",
        "name": "Kyrgyzstan"
    },
    {
        "id": "21aa4b19-0221-4293-a2cb-bb8ee52535ac",
        "name": "Finland"
    },
    {
        "id": "12de1c29-350e-4b58-a5cf-99d430999048",
        "name": "Laos"
    },
    {
        "id": "e8287956-7633-4100-b1b0-33dfab44a1e3",
        "name": "France"
    },
    {
        "id": "1abd9d04-e0de-462a-a10e-97468ee343ef",
        "name": "Hungary"
    },
    {
        "id": "bb55b137-d061-4c6f-9ddd-fe3ae048316b",
        "name": "Lebanon"
    },
    {
        "id": "13cbc9a6-0367-4d44-9a00-86210cc44e45",
        "name": "Honduras"
    },
    {
        "id": "9827e3cf-d41b-40b9-9bb4-2868cea388b5",
        "name": "Guyana"
    },
    {
        "id": "2ce32089-0b76-4c0d-94a7-64b7b754eef5",
        "name": "East Timor"
    },
    {
        "id": "90abed11-2687-4132-bdd3-3b6854dd767b",
        "name": "Ecuador"
    },
    {
        "id": "af5a6b3c-2bc0-4c48-af79-501ddd97de6c",
        "name": "Egypt"
    },
    {
        "id": "53b60e01-62d9-4ec0-a123-5341e97cf84d",
        "name": "El Salvador"
    }
];

export default function CountryList() {
    let key = 0;
    const options = data.map((item) => {
        key++;
        return <option id={item.id} key={key}>{item.name}</option>
    })

    return (options)
}