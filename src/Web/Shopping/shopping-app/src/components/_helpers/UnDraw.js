import React from 'react';

export const UnDrawServerDown = 'undraw_server_down_s4lk'
export const UnDrawBlankCanvas =  'undraw_blank_canvas_3rbb'
export const UnDrawBugFixing = 'undraw_bug_fixing_oc7a'
export const UnDrawCancel =  'undraw_cancel_u1it'
export const UnDrawPageNotFound =  'undraw_page_not_found_su7k'
export const UnDrawQAEngineers =  'undraw_QA_engineers_dg5p'
export const UnDrawWarning =  'undraw_warning_cyit'
export const UnDrawNotFound =  'undraw_not_found_60pq'
export const UnDrawEmpty =  'empty'

const UnDraw = props => {
    const width = window.innerWidth < 768 ? "200px" : "300px";
    const baseUrl = 'https://smitha-cdn.s3.us-east-2.amazonaws.com/Content/vendor/unDraw/'
    let svg = ''
    switch(props.svg){
        case undefined:
        case null: 
        case '': 
            const svgs = [ 
                UnDrawServerDown,
                UnDrawBlankCanvas,
                UnDrawBugFixing,
                UnDrawCancel,
                UnDrawPageNotFound,
                UnDrawQAEngineers,
                UnDrawWarning,
                UnDrawNotFound,
                UnDrawEmpty
            ]
            svg = svgs[Math.floor(Math.random() * svgs.length)]
            break;
        default:
            svg = props.svg
            break;
    }
    return <img width={width} src={baseUrl + svg + '.svg'} alt={props.svg} {...props} />
}
export default UnDraw