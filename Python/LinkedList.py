class Node:
    def __init__(self, content):
        self._next = None
        self._previous = None

        self.content = content


if __name__ == '__main__':
    node = Node("me")
    node._next = 1
    print(node._next)
