import React, {Component} from 'react';
import {Table} from 'react-bootstrap';
import {Button, ButtonToolbar} from 'react-bootstrap';
import {AddCategoryModal} from './AddCategoryModal';
import {EditCategoryModal} from './EditCategoryModal';

export class Category extends Component {
    
    constructor(props){
        super(props);
        this.state = {categories:[], addModalShow:false, editModalShow:false}
    }

    componentDidMount(){
        this.refreshList();    
    }

    refreshList(){
        fetch('https://localhost:44357/api/category')
        .then(response => response.json()
        .then(data => {
            this.setState({categories:data});
        }));
    }

    componentDidUpdate(){
        this.refreshList();
    }

    deleteCat(catid){
        if(window.confirm('Are you sure you want to delete this row?')){
            fetch('https://localhost:44357/api/category/' + catid, {
                method:'DELETE',
                header:{
                    'Accept':'application/json',
                    'Content-type':'application/json'
                    }
            })
        }
    }

    render(){
        const {categories, catid, catname} = this.state;
        let addModalClose = () => this.setState({addModalShow:false});
        let editModalClose = () => this.setState({editModalShow:false});

        return(
        <div>
            <Table className="mt-4" striped bordered hover size="sm">
                <thead>
                    <tr>
                        <th>CategoryID</th>
                        <th>Category</th>
                        <th>Options</th>
                    </tr>
                </thead>
                <tbody>
                    {categories.map(cat => (
                        <tr key = {cat.CategoryID}> 
                            <td>{cat.CategoryID}</td>
                            <td>{cat.CategoryName}</td>
                            <td>
                                <ButtonToolbar>
                                    <Button
                                    className="mr-2" variant="info"
                                    onClick={() => this.setState({editModalShow:true, catid:cat.CategoryID, catname:cat.CategoryName})}>
                                        Edit
                                    </Button>
                                    <Button 
                                    className='mr-2' variant="danger"
                                    onClick={() => this.deleteCat(cat.CategoryID)}>
                                        Delete
                                    </Button>
                                    <EditCategoryModal 
                                    show={this.state.editModalShow}
                                    onHide={editModalClose}
                                    catid={catid}
                                    catname={catname}
                                    />
                                </ButtonToolbar>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </Table>
            <ButtonToolbar>
                <Button variant='primary' onClick={ () => this.setState({addModalShow: true})}>
                Add Category
                </Button>
                <AddCategoryModal show={this.state.addModalShow} onHide={addModalClose}/>
            </ButtonToolbar>
        </div>
        )
    }
}