import React from 'react';
import { Col, Row } from 'reactstrap';
import UnDraw from './UnDraw';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faExclamationTriangle } from '@fortawesome/free-solid-svg-icons'


const ErrorMessage = props => {
    let message = props.message !== undefined ? props.message : ''
    return (
        <Row>
            <Col xs="12">
                <UnDraw className="d-block mx-auto" />
            </Col>
            <Col xs="12">
                <Row className="h-100 justify-content-center align-items-center">
                    <Col>
                        <p className="lead mt-2 text-muted text-center">
                            <FontAwesomeIcon icon={faExclamationTriangle} />&nbsp;
                            {message}
                        </p>
                    </Col>
                </Row>
            </Col>
        </Row>
    )
}

export default ErrorMessage