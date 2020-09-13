import React, { Component } from 'react';


export class ContentLimitItems extends Component {
    constructor(props) {
        super(props);
        this.state = {
            items: []
        }
        this.notifyParent = this.props.updateNotification;
        this.onDelete = this.onDelete.bind(this);
    }

    static getDerivedStateFromProps(nextProps, prevState) {
        return {
            items: nextProps.itemsDictionary[nextProps.categoryId]
        };
    }

    async onDelete(itemId) {
        await fetch('ContentLimit/Items/' + itemId, {
            method: 'DELETE'
        });
        this.notifyParent(this.props.categoryId);
    }

    render() {
        if (this.state.items === undefined) {
            return (<div />);
        }

        return (
            <div>
                {
                    this.state.items.map((item, itemIndex) => {
                        return(
                            <div>
                                <h3> {item.name}  {item.value} <button onClick={() => this.onDelete(item.id)}>Delete</button> </h3>
                            </div>
                        )
                    })
                }
            </div>
            );
    }
}