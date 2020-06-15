import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { UserConsumer } from '../contexts/UserContext';
import { merchant_name, app_display_name } from '../app.config.json'
import { merchantService } from '../services/merchant.service'
import Loading from './_helpers/Loading'
import ErrorMessage from './_helpers/ErrorMessage'
import './Home.css'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faMapMarker, faClock } from '@fortawesome/free-solid-svg-icons';


export class Home extends Component {
    constructor(props){
        super(props)
        this.state = {
            merchantId: 2,
            merchant: {
                loading: true,
                success: null,
                data: null
            },
            items: {
                loading: true,
                success: null,
                data: null
            },
            itemTypes: {
                loading: true,
                success: null,
                data: null
            }
        }
    }
    componentDidMount(){
        this.populateMerchantInformation()
    }

    populateMerchantInformation = async() => {
        const data = await merchantService.getMerchant(this.state.merchantId)
        if(data){
            this.setState({
                merchant: {
                    success: data !== null,
                    data: data,
                    loading: false
                }
            })
        }
    }

    render() {
        const { merchant, items, itemTypes } = this.state
        return (
            <div>
                {merchant.loading 
                ? <div>
                    <section className="pt-7 pb-5 d-flex align-items-end dark-overlay bg-cover">
                        <div className="container overlay-content">
                            <div className="d-flex justify-content-between align-items-start flex-column flex-lg-row align-items-lg-end">
                                <div className="text-white mb-4 mb-lg-0">
                                    <h1 className="text-shadow verified">
                                        <Loading message={'Loading [merchant_name], please wait..'.replace('[merchant_name]', merchant_name)} />
                                    </h1>
                                </div>
                            </div>
                        </div>
                    </section>
                    <section className="pb-6">
                        <div className="container">
                            <div className="row">
                                <div className="col-md-8">
                                    <h2 className="mb-2">About</h2>
                                    <Loading />
                                </div>
                                <div className="col-md-4">
                                    <h2 className="mb-2">Location</h2>
                                    <Loading />
                                </div>
                            </div>
                        </div>
                    </section>
                </div>
                : merchant.success
                ? Home.renderMerchant(merchant.data)
                : <ErrorMessage message={'Could not load [merchant_name].'.replace('[merchant_name]', merchant_name)} /> }
            </div>
        );
    }

    static renderMerchant(merchant) {
        return (
            <div>
                <section className="pt-7 pb-5 d-flex align-items-end dark-overlay bg-cover" style={{
                    backgroundImage: 'url(:url)'.replace(':url', merchant.defaultImageUrl)
                }}>
                    <div className="container overlay-content">
                        <div className="d-flex justify-content-between align-items-start flex-column flex-lg-row align-items-lg-end">
                            <div className="text-white mb-4 mb-lg-0">
                                <div className="badge badge-pill badge-transparent px-3 py-2 mb-4">{merchant.merchantTypeName}</div>
                                <h1 className="text-shadow verified">{merchant.name}</h1>
                                <p><FontAwesomeIcon icon={faMapMarker} />&nbsp;{merchant.displayLocation}</p>
                                <span className="d-block">
                                    <span className="text-white">
                                        <FontAwesomeIcon icon={faClock} />&nbsp;
                                        {merchant.operatingHours}
                                    </span>
                                </span>
                            </div>
                            <button type="button" className="btn btn-primary btn-lg mb-3">
                                See our services
                            </button>
                        </div>
                    </div>
                </section>
                <section className="py-5">
                    <div className="container">
                        <div className="row">
                            <div className="col-md-8">
                                <h2 className="mb-2">About</h2>
                                <p className="lead">{merchant.shortDescription}</p>
                                <p className="text-muted">
                                    {merchant.description}
                                </p>
                                <hr className="mb-0" />
                            </div>
                            <div className="col-md-4">
                                <h2 className="mb-2">Location</h2>
                                <div className="list-group border-0 shadow mb-5">
                                    <div className="list-group-item">
                                        <address className="mb-1">
                                            {merchant.displayLocation}
                                        </address>
                                        <address className="small text-muted">
                                            <abbr title="Hours">H:</abbr>
                                            {merchant.operatingHours}
                                            <br />
                                            <abbr title="Phone">P:</abbr>
                                            {merchant.phone}
                                            <br />
                                            <abbr title="Email">E:</abbr>
                                            <a href={'mailto:{0}'.replace('{0}', merchant.contactEmail)}>{merchant.contactEmail}</a>
                                        </address>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        )
    }
}