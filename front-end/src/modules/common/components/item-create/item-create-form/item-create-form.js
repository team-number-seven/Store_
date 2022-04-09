import {BrandList} from "../../lists/brand-list/brand-list";
import {ColorList} from "../../lists/color-list/color-list";
import {AgeList} from "../../lists/age-list/age-list";
import {SizeList} from "../../lists/size-list/size-list";
import {TypeList} from "../../lists/type-list/type-list";
import {GenderList} from "../../lists/gender-list/gender-list";
import {SeasonList} from "../../lists/season-list/season-list";
import {useForm} from "react-hook-form";

const uploadFile = async (e) => {
    const formData = new FormData(document.querySelector('#item-create-form'));

    await fetch("https://localhost:5001/Store/Item/Create", {
        method: "POST",
        body: formData
    })
}

export const ItemCreateForm = ({Brands, Colors, Types, Genders, Seasons, Sizes, Ages}) => {


    const {
        formState: {errors, isValid},
        handleSubmit,
        register,
        reset,
        getValues,
    } = useForm({
            mode: 'all'
        }
    );

    const onSubmit = () => {

    }


    return (
        <form id={'item-create-form'}
              className="container form-group"
              onSubmit={handleSubmit(onSubmit)}
        >

            <input name={'Title'}
                   type={'text'}
                   className="form-control"
                   placeholder={'Title'}
                   {...register('title', {
                       required: {
                           value: true,
                           message: 'This field cannot be empty',
                       },
                       pattern: {
                           value: /^[a-zA-Z\s]*$/,
                           message: 'Invalid title',
                       }
                   })}
            />
            {errors?.title && <small className="input-error">{errors?.title?.message}</small>}

            <input name={'Description'}
                   type={'text'}
                   className="form-control"
                   placeholder={'Description'}
                   {...register('description', {
                       required: {
                           value: true,
                           message: 'This field cannot be empty',
                       },
                       pattern: {
                           value: /[^a-zA-Z0-9]/g,
                           message: 'Invalid description',
                       }
                   })}
            />
            {errors?.description && <small className="input-error">{errors?.description?.message}</small>}

            <input name={'Price'}
                   type={'text'}
                   className="form-control"
                   placeholder={'Price'}
                   {...register('price', {
                       required: {
                           value: true,
                           message: 'This field cannot be empty',
                       },
                       pattern: {
                           value: /^(\d*([.,](?=\d{3}))?\d+)+((?!\2)[.,]\d\d)?$/,
                           message: 'Invalid price',
                       }
                   })}
            />
            {errors?.price && <small className="input-error">{errors?.price?.message}</small>}


            <input name={'ArticleNumber'}
                   type={'text'}
                   className="form-control"
                   placeholder={'Article Number'}
                   {...register('articleNumber', {
                       required: {
                           value: true,
                           message: 'This field cannot be empty',
                       },
                       pattern: {
                           value: /^[A-Z0-9 _]*[A-Z0-9][A-Z0-9 _]*$/,
                           message: 'Invalid article number',
                       }
                   })}
            />
            {errors?.articleNumber && <small className="input-error">{errors?.articleNumber?.message}</small>}


            <select id="brand-list"
                    className="form-control selectpicker"
                    data-live-search="true"
                    data-width="fit"
                    defaultValue={''}
                    {...register('brand', {
                        required: {
                            value: true,
                            message: 'This field cannot be empty',
                        }
                    })}
            >
                <BrandList Brands={Brands}/>
            </select>
            {errors?.brand && <small className="input-error">{errors?.brand?.message}</small>}


            <select id="color-list"
                    className="form-control selectpicker"
                    data-live-search="true"
                    data-width="fit"
                    defaultValue={''}
                    {...register('color', {
                        required: {
                            value: true,
                            message: 'This field cannot be empty',
                        }
                    })}
            >
                <ColorList Colors={Colors}/>
            </select>
            {errors?.color && <small className="input-error">{errors?.color?.message}</small>}


            <select id="age-list"
                    className="form-control selectpicker"
                    data-live-search="true"
                    data-width="fit"
                    defaultValue={''}
                    {...register('age', {
                        required: {
                            value: true,
                            message: 'This field cannot be empty',
                        },
                    })}
            >
                <AgeList Ages={Ages}/>
            </select>
            {errors?.age && <small className="input-error">{errors?.age?.message}</small>}


            <select id="size-list"
                    className="form-control selectpicker"
                    data-live-search="true"
                    data-width="fit"
            >
                <SizeList Sizes={Sizes}/>
            </select>


            <select id="type-list"
                    className="form-control selectpicker"
                    data-live-search="true"
                    data-width="fit"
                    defaultValue={''}
                    {...register('type', {
                        required: {
                            value: true,
                            message: 'This field cannot be empty',
                        },
                    })}
            >
                <TypeList Types={Types}/>
            </select>
            {errors?.type && <small className="input-error">{errors?.type?.message}</small>}


            <select id="gender-list"
                    className="form-control selectpicker"
                    data-live-search="true"
                    data-width="fit"
                    defaultValue={''}
                    {...register('gender', {
                        required: {
                            value: true,
                            message: 'This field cannot be empty',
                        },
                    })}
            >
                <GenderList Genders={Genders}/>
            </select>
            {errors?.gender && <small className="input-error">{errors?.gender?.message}</small>}


            <select id="season-list"
                    className="form-control selectpicker"
                    data-live-search="true"
                    data-width="fit"
                    defaultValue={''}
                    {...register('season', {
                        required: {
                            value: true,
                            message: 'This field cannot be empty',
                        },
                    })}
            >
                <SeasonList Seasons={Seasons}/>
            </select>
            {errors?.season && <small className="input-error">{errors?.season?.message}</small>}


            <input name={'Files'} type={'file'}/>
            <input name={'Files'} type={'file'} multiple/>

            <button className="btn btn-primary"
                    type="submit"
                    onClick={uploadFile}
                    disabled={!isValid}
            >
                Upload
            </button>
        </form>
    )
}