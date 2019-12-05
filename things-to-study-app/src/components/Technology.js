import React, {Component} from 'react';
import {Table} from 'react-bootstrap';
import {Button, ButtonToolbar} from 'react-bootstrap';
import {AddTechnologyModal} from './AddTechnologyModal';
import {EditTechnologyModal} from './EditTechnologyModal';

export class Technology extends Component {

    constructor(props){
        super(props);
        this.state = {technologies:[], addModalShow:false, editModalShow:false}
    }

    componentDidMount(){
        this.refreshList();    
    }

    refreshList(){
        fetch('https://localhost:44357/api/technology')
        .then(response => response.json()
        .then(data => {
            this.setState({technologies:data});
        }));
    }

    componentDidUpdate(){
        this.refreshList();
    }

    deleteTech(techid){
        if(window.confirm('Are you sure you want to delete this row?')){
            fetch('https://localhost:44357/api/technology/' + techid, {
                method:'DELETE',
                header:{
                    'Accept':'application/json',
                    'Content-type':'application/json'
                    }
            })
        }
    }

    render(){
        const {technologies, techid, techname, categories, techdes, techurl} = this.state;
        let addModalClose = () => this.setState({addModalShow:false});
        let editModalClose = () => this.setState({editModalShow:false});

        return(
            <div>
            <Table className="mt-4" striped bordered hover size="sm">
                <thead>
                    <tr>
                        <th>TechID</th>
                        <th>Technology</th>
                        <th>Category</th>
                        <th>Description</th>
                        <th>URL</th>
                        <th>Options</th>
                    </tr>
                </thead>
                <tbody>
                    {technologies.map(tech => (
                        <tr key = {tech.TechID}> 
                            <td>{tech.TechID}</td>
                            <td>{tech.TechName}</td>
                            <td>{tech.Category}</td>
                            <td>{tech.TechDescription}</td>
                            <td>{tech.TechURL}</td>
                            <td>
                                <ButtonToolbar>
                                    <Button
                                    className="mr-2" variant="info"
                                    onClick={() => this.setState({editModalShow:true, techid:tech.TechID, techname:tech.TechName, categories:tech.Category, techdes:tech.TechDescription, techurl:tech.TechURL})}>
                                        Edit
                                    </Button>
                                    
                                    <Button 
                                    className='mr-2' variant="danger"
                                    onClick={() => this.deleteTech(tech.TechID)}>
                                        Delete
                                    </Button>

                                    <EditTechnologyModal 
                                    show={this.state.editModalShow}
                                    onHide={editModalClose}
                                    techid={techid}
                                    techname={techname}
                                    categories={categories}
                                    techdes={techdes}
                                    techurl={techurl}
                                    />
                                </ButtonToolbar>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </Table>
            <ButtonToolbar>
                <Button variant='primary' onClick={ () => this.setState({addModalShow: true})}>
                Add Technology
                </Button>
                <AddTechnologyModal show={this.state.addModalShow} onHide={addModalClose}/>
            </ButtonToolbar>
        </div>
        )
    }
}