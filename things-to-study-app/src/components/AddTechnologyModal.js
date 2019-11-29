import React, {Component} from 'react';
import {Modal, Button, Row, Col, Form} from 'react-bootstrap';
import Snackbar from '@material-ui/core/Snackbar';
import IconButton from '@material-ui/core/IconButton';

export class AddTechnologyModal extends Component{

    constructor(props){
        super(props);
        this.state = {categories:[], snackbaropen: false, snackbarmsg: ''};
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    componentDidMount(){
        fetch('https://localhost:44357/api/category')
        .then(response => response.json())
        .then(data => {
            this.setState({categories:data});
        });
    }

    snackbarClose = (event) => {
        this.setState({snackbaropen: false});
    };

    handleSubmit(event){
        event.preventDefault();
        
        fetch('https://localhost:44357/api/technology',{
            method:'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                TechID:null,
                TechName: event.target.TechName.value,
                CatName: event.target.Category.value,
                TechDes: event.target.TechDescription.value,
                TechURL: event.target.TechURL.value
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
          Add Technology
        </Modal.Title>
      </Modal.Header>
      <Modal.Body>
            <Row>
                <Col sm={6}>
                    <Form onSubmit={this.handleSubmit}>
                        <Form.Group controlId="TechName">
                            <Form.Label>Technology</Form.Label>
                            <Form.Control type="text" name="TechName" required placeholder="Name"/>
                        </Form.Group>

                        <Form.Group controlId="Category">
                            <Form.Label>Category</Form.Label>
                            <Form.Control as="select">
                                {this.state.categories.map(cat =>
                                <option key={cat.CategoryID}>{cat.CategoryName}</option>
                                    )}
                            </Form.Control>
                        </Form.Group>

                        <Form.Group controlId="TechDescription">
                            <Form.Label>Description</Form.Label>
                            <Form.Control type="text" name="TechDescription" required placeholder="Description"/>
                        </Form.Group>

                        <Form.Group controlId="TechURL">
                            <Form.Label>URL</Form.Label>
                            <Form.Control type="text" name="TechURL" required placeholder="URL"/>
                        </Form.Group>

                        <Form.Group>
                            <Button variant="primary" type="submit">
                                Add Technology
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