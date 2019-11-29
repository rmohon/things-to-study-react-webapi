import React, {Component} from 'react';
import {Modal, Button, Row, Col, Form} from 'react-bootstrap';
import Snackbar from '@material-ui/core/Snackbar';
import IconButton from '@material-ui/core/IconButton';

export class AddCategoryModal extends Component{

    constructor(props){
        super(props);
        this.state = {snackbaropen: false, snackbarmsg: ''};
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    snackbarClose = (event) => {
        this.setState({snackbaropen: false});
    };

    handleSubmit(event){
        event.preventDefault();
        
        fetch('https://localhost:44357/api/category',{
            method:'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                CatID:null,
                CatName: event.target.CategoryName.value
            })
        })
        .then(res => res.json())
        .then((result) => {
            this.setState({snackbaropen:true, snackbarmsg:result});
        },
        (error) => {
            this.setState({snackbaropen:true, snackbarmsg:'Failed'});
        })
    }

    render(){
        return(
    <div className="container">
    <Snackbar 
    anchorOrigin={{vertical:'center', horizontal:'center'}}
    open={this.state.snackbaropen}
    autoHideDuration={3000}
    onClose={this.snackbarClose}
    message={<span id="message-id">{this.state.snackbarmsg}</span>}
    action={[
        <IconButton key="close" arial-label="Close" color="inherit" onClick={this.snackbarClose}>
            x
        </IconButton>
    ]}
    />
    <Modal
      {...this.props}
      size="lg"
      aria-labelledby="contained-modal-title-vcenter"
      centered>

      <Modal.Header closeButton>
        <Modal.Title id="contained-modal-title-vcenter">
          Add Category
        </Modal.Title>
      </Modal.Header>
      <Modal.Body>
            <Row>
                <Col sm={6}>
                    <Form onSubmit={this.handleSubmit}>
                        <Form.Group controlId="CategoryName">
                            <Form.Label>Category Name</Form.Label>
                            <Form.Control type="text" name="CategoryName" required placeholder="Category"/>
                        </Form.Group>

                        <Form.Group>
                            <Button variant="primary" type="submit">
                                Add Category
                            </Button>
                        </Form.Group>
                    </Form>
                </Col>
            </Row>
      </Modal.Body>
      <Modal.Footer>
        <Button variant="danger" onClick={this.props.onHide}>Close</Button>
      </Modal.Footer>
      </Modal>
    </div>
        );
    }
}