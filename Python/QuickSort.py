class QuickSort:

    @staticmethod
    def __partition(array: list, low: int, high: int) -> int:
        x = array[high]
        i = low - 1

        for j in range(low, high, 1):
            if array[j] <= x:
                i += 1
                array[i], array[j] = array[j], array[i]

        array[i + 1], array[high] = array[high], array[i + 1]
        return i + 1

    def sort(self, array: list, low: int, high: int):
        if low < high:
            part = self.__partition(array, low, high)
            # print(array)
            self.sort(array, low, part - 1)
            self.sort(array, part + 1, high)


if __name__ == '__main__':
    arr = [2, 8, 7, 1, 3, 5, 6, 4]
    qs = QuickSort()
    qs.sort(arr, 0, len(arr) - 1)

    print(arr)
